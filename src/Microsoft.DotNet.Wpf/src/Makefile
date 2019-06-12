RESX2SR = mono ~/Code/wpf/resx2sr.exe
CSC = csc -target:library
CSFLAGS = -unsafe -delaysign+ -keyfile:winfx3.pub -langversion:7.3 -nowarn:CS0436 -nowarn:CS0618 -nostdlib -noconfig -lib:/usr/lib/mono/4.5-api
CSLIBS = -r:mscorlib.dll -r:System.dll -r:System.Configuration.dll -r:System.Core.dll -r:System.Drawing.dll -r:System.Xml.dll -r:System.Windows.dll

all:

clean:
	rm -f *.flags *.names *.dll *.resources.cs *.Strings.resources

%.System.SRID.resources.cs: %/Resources/Strings.resx
	$(RESX2SR) -n System.SRID $< -o $@ || rm -f $@
%.System.SR.resources.cs: %/Resources/Strings.resx
	$(RESX2SR) -n System.SR $< -o $@ || rm -f $@
%.Strings.resources: %/Resources/Strings.resx
	resgen $< $@
MS.Internal.WindowsBase.SRID.resources.cs: WindowsBase/Resources/Strings.resx
	$(RESX2SR) -n MS.Internal.WindowsBase.SRID $< -o $@ || rm -f $@
MS.Internal.Automation.SRID.resources.cs: UIAutomation/UIAutomationProvider/Resources/Strings.resx
	$(RESX2SR) -n MS.Internal.Automation.SRID $< -o $@ || rm -f $@
MS.Internal.PresentationCore.SRID.resources.cs: PresentationCore/Resources/Strings.resx
	$(RESX2SR) -n MS.Internal.PresentationCore.SRID $< -o $@ || rm -f $@

%.resources.names: %.resources.list
	cat $< | sed 's:^.*/Resources/::g; s:/ToolStrip/:/:g; s:\\.ico$$::g; s:/:.:g' >$@ || rm -f $@
%.resources.flags: %.resources.list %.resources.names
	paste -d, $*.resources.list $*.resources.names | xargs -r printf '-resource:%s\n' >$@ || rm -f $@

DEBUG_CSFLAGS = -define:TRACE  -define:DEBUG
# -define:NETCOREAPP -define:NETCOREAPP3_0

System.Xaml_CSFLAGS = -define:OLDRESOURCES -define:SYSTEM_XAML
System.Xaml_CSLIBS =
System.Xaml_CSREFS =
System.Xaml_CSSRCS = System.SRID.cs System.Xaml.System.SRID.resources.cs

WindowsBase_CSFLAGS = -define:BASE_NATIVEMETHODS -define:WINDOWS_BASE
WindowsBase_CSLIBS = System.Xaml.dll
WindowsBase_CSREFS = /usr/lib/mono/4.5-api/WindowsBase.dll System.Security.dll Accessibility.dll
WindowsBase_CSSRCS = WindowsBase.PackageXmlStringTable.cs MS.Internal.WindowsBase.SRID.cs MS.Internal.WindowsBase.SRID.resources.cs

System.Windows.Input.Manipulations_CSFLAGS =
System.Windows.Input.Manipulations_CSLIBS =
System.Windows.Input.Manipulations_CSREFS =
System.Windows.Input.Manipulations_CSSRCS = System.SR.cs System.Windows.Input.Manipulations.System.SR.resources.cs

UIAutomationTypes_CSFLAGS = -define:UIAUTOMATIONTYPES
UIAutomationTypes_CSLIBS = System.Xaml.dll WindowsBase.dll
UIAutomationTypes_CSREFS = Accessibility.dll
UIAutomationTypes_CSSRCS = System.SR.cs UIAutomation/UIAutomationTypes.System.SR.resources.cs

UIAutomationProvider_CSFLAGS = -define:AUTOMATION
UIAutomationProvider_CSLIBS = UIAutomationTypes.dll WindowsBase.dll
UIAutomationProvider_CSREFS =
UIAutomationProvider_CSSRCS = MS.Internal.Automation.SRID.cs MS.Internal.Automation.SRID.resources.cs

TextInterface_CSFLAGS = -define:AUTOMATION -define:USE_CAIRO \
  -nowarn:CS0626 -nowarn:CS0824
TextInterface_CSLIBS = WindowsBase.dll
TextInterface_CSREFS = Mono.Cairo.dll
TextInterface_CSSRCS =

PresentationCore_CSFLAGS = \
 -define:CORE_NATIVEMETHODS \
 -define:PRESENTATION_CORE \
 -define:COMMONDPS \
 -nowarn:CS3021
PresentationCore_CSLIBS = System.Xaml.dll WindowsBase.dll System.Windows.Input.Manipulations.dll UIAutomationTypes.dll UIAutomationProvider.dll TextInterface.dll
PresentationCore_CSREFS =
PresentationCore_CSSRCS = MS.Internal.PresentationCore.SRID.cs MS.Internal.PresentationCore.SRID.resources.cs

WindowsBase.PackageXmlStringTable.cs:
	perl ../../../../wpf/eng/WpfArcadeSdk/Sdk/tools/GenXmlStringTable.pl -o $@ \
		-n WindowsBase/MS/Internal/IO/Packaging/PackageXmlNamespaces.txt \
		-x WindowsBase/MS/Internal/IO/Packaging/PackageXmlStrings.txt \
		-e MS.Internal.IO.Packaging.PackageXmlEnum \
		-c MS.Internal.IO.Packaging.PackageXmlStringTable

define DLL_template =
$(1).sources: $(1).sources.list $(shell cat $(1).sources.list)
$(1).resources: $(1).resources.flags $(shell cat $(1).resources.list)
$(1).dll: $(1).sources $(1).resources $($(1)_CSSRCS) $($(1)_CSLIBS)
	$(CSC) $(CSFLAGS) $(CSLIBS) $($(1)_CSFLAGS) $(addprefix -r:,$($(1)_CSLIBS)) $(addprefix -r:,$($(1)_CSREFS)) -out:$$@ \
	  @$(1).sources.list $($(1)_CSSRCS) @$(1).resources.flags
endef

$(eval $(call DLL_template,System.Xaml))
$(eval $(call DLL_template,WindowsBase))
$(eval $(call DLL_template,System.Windows.Input.Manipulations))
$(eval $(call DLL_template,UIAutomationTypes))
$(eval $(call DLL_template,UIAutomationProvider))
$(eval $(call DLL_template,TextInterface))
$(eval $(call DLL_template,PresentationCore))
