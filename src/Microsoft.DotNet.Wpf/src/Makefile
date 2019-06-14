WINE_MONO_SRCDIR ?= ../../../../wine-mono
MONO_PREFIX ?= /usr

RESX2SR = mono $(WINE_MONO_SRCDIR)/mono/mcs/class/lib/build-linux/resx2sr.exe
CSC_LIBRARY = csc -target:library
CSC_MODULE = csc -target:module
CSFLAGS = -unsafe -delaysign+ -keyfile:winfx3.pub -langversion:7.3 -nowarn:CS0436 -nowarn:CS0618 -nostdlib -noconfig -lib:$(MONO_PREFIX)/lib/mono/4.5-api -define:MONO
CSLIBS = -r:mscorlib.dll -r:System.dll -r:System.Configuration.dll -r:System.Core.dll -r:System.Drawing.dll -r:System.Xml.dll -r:System.Windows.dll

all:

clean:
	rm -f *.flags *.names *.dll *.resources.cs *.generated.cs *.Strings.resources

%.Strings.resources: %/Resources/Strings.resx
	resgen $< $@
UIAutomation.%.Strings.resources: UIAutomation/%/Resources/Strings.resx
	resgen $< $@
%.System.SRID.resources.cs: %/Resources/Strings.resx
	$(RESX2SR) -n System.SRID $< -o $@ || rm -f $@
%.System.SR.resources.cs: %/Resources/Strings.resx
	$(RESX2SR) -n System.SR $< -o $@ || rm -f $@
UIAutomation.%.System.SR.resources.cs: UIAutomation/%/Resources/Strings.resx
	$(RESX2SR) -n System.SR $< -o $@ || rm -f $@
MS.Internal.WindowsBase.SRID.resources.cs: WindowsBase/Resources/Strings.resx
	$(RESX2SR) -n MS.Internal.WindowsBase.SRID $< -o $@ || rm -f $@
MS.Internal.Automation.SRID.resources.cs: UIAutomation/UIAutomationProvider/Resources/Strings.resx
	$(RESX2SR) -n MS.Internal.Automation.SRID $< -o $@ || rm -f $@
MS.Internal.PresentationCore.SRID.resources.cs: PresentationCore/Resources/Strings.resx
	$(RESX2SR) -n MS.Internal.PresentationCore.SRID $< -o $@ || rm -f $@
System.Windows.Xps.SRID.resources.cs: ReachFramework/Resources/Strings.resx
	$(RESX2SR) -n System.Windows.Xps.SRID $< -o $@ || rm -f $@
System.Windows.SRID.resources.cs: PresentationFramework/Resources/Strings.resx
	$(RESX2SR) -n System.Windows.SRID $< -o $@ || rm -f $@

%.resources.names: %.resources.list
	cat $< | sed 's:^.*/Resources/::g; s:/ToolStrip/:/:g; s:\\.ico$$::g; s:/:.:g' >$@ || rm -f $@
%.resources.flags: %.resources.list %.resources.names
	paste -d, $*.resources.list $*.resources.names | xargs -r printf '-resource:%s\n' >$@ || rm -f $@
%.sources.flags: %.sources.list
	sed 's:$$(WINE_MONO_SRCDIR):$(WINE_MONO_SRCDIR):g' $< >$@ || rm -f $@

DEBUG_CSFLAGS = -define:TRACE  -define:DEBUG
# -define:NETCOREAPP -define:NETCOREAPP3_0

System.Xaml_CSFLAGS = -define:OLDRESOURCES -define:SYSTEM_XAML
System.Xaml_CSLIBS =
System.Xaml_CSREFS =
System.Xaml_CSSRCS = System.SRID.cs System.Xaml.System.SRID.resources.cs

WindowsBase_CSFLAGS = -define:BASE_NATIVEMETHODS -define:WINDOWS_BASE
WindowsBase_CSLIBS = System.Xaml.dll
WindowsBase_CSREFS = /usr/lib/mono/4.5-api/WindowsBase.dll System.Security.dll Accessibility.dll
WindowsBase_CSSRCS = WindowsBase.PackageXmlStringTable.generated.cs MS.Internal.WindowsBase.SRID.cs MS.Internal.WindowsBase.SRID.resources.cs

System.Windows.Input.Manipulations_CSFLAGS =
System.Windows.Input.Manipulations_CSLIBS =
System.Windows.Input.Manipulations_CSREFS =
System.Windows.Input.Manipulations_CSSRCS = System.SR.cs System.Windows.Input.Manipulations.System.SR.resources.cs

UIAutomationTypes_CSFLAGS = -define:UIAUTOMATIONTYPES
UIAutomationTypes_CSLIBS = System.Xaml.dll WindowsBase.dll
UIAutomationTypes_CSREFS = Accessibility.dll
UIAutomationTypes_CSSRCS = System.SR.cs UIAutomation.UIAutomationTypes.System.SR.resources.cs

UIAutomationProvider_CSFLAGS = -define:AUTOMATION
UIAutomationProvider_CSLIBS = UIAutomationTypes.dll WindowsBase.dll
UIAutomationProvider_CSREFS =
UIAutomationProvider_CSSRCS = MS.Internal.Automation.SRID.cs MS.Internal.Automation.SRID.resources.cs

PresentationCore_CSFLAGS = -define:CORE_NATIVEMETHODS -define:PRESENTATION_CORE -define:COMMONDPS -nowarn:CS3021 -nowarn:CS1058
PresentationCore_CSLIBS = System.Xaml.dll WindowsBase.dll System.Windows.Input.Manipulations.dll UIAutomationTypes.dll UIAutomationProvider.dll
PresentationCore_CSREFS =
PresentationCore_CSSRCS = MS.Internal.PresentationCore.SRID.cs MS.Internal.PresentationCore.SRID.resources.cs

PresentationFramework-PresentationUI-api_CSFLAGS =
PresentationFramework-PresentationUI-api_CSLIBS =
PresentationFramework-PresentationUI-api_CSREFS =
PresentationFramework-PresentationUI-api_CSSRCS =

ReachFramework-PresentationFramework-api_CSFLAGS = -define:REACHFRAMEWORK
ReachFramework-PresentationFramework-api_CSLIBS =
ReachFramework-PresentationFramework-api_CSREFS =
ReachFramework-PresentationFramework-api_CSSRCS =

ReachFramework-System.Printing-api_CSFLAGS = -define:REACHFRAMEWORK
ReachFramework-System.Printing-api_CSLIBS =
ReachFramework-System.Printing-api_CSREFS =
ReachFramework-System.Printing-api_CSSRCS =

System.Printing-PresentationFramework-api_CSFLAGS = -define:REACHFRAMEWORK
System.Printing-PresentationFramework-api_CSLIBS =
System.Printing-PresentationFramework-api_CSREFS =
System.Printing-PresentationFramework-api_CSSRCS =

PresentationFramework-System.Printing-api_CSFLAGS =
PresentationFramework-System.Printing-api_CSLIBS = \
	System.Xaml.dll \
	WindowsBase.dll \
	System.Windows.Input.Manipulations.dll \
	UIAutomationTypes.dll \
	UIAutomationProvider.dll \
	PresentationCore.dll \
	ReachFramework-PresentationFramework-api.dll \
	System.Printing-PresentationFramework-api.dll
PresentationFramework-System.Printing-api_CSREFS =
PresentationFramework-System.Printing-api_CSSRCS =

PresentationUI-PresentationFramework-impl_CSFLAGS =
PresentationUI-PresentationFramework-impl_CSLIBS = \
  System.Xaml.dll \
  WindowsBase.dll \
  System.Windows.Input.Manipulations.dll \
  UIAutomationTypes.dll \
  UIAutomationProvider.dll \
  PresentationCore.dll \
  PresentationFramework-PresentationUI-api.dll
PresentationUI-PresentationFramework-impl_CSREFS =
PresentationUI-PresentationFramework-impl_CSSRCS =

PresentationFramework-ReachFramework-impl_CSFLAGS =
PresentationFramework-ReachFramework-impl_CSLIBS = \
	System.Xaml.dll \
	WindowsBase.dll \
	System.Windows.Input.Manipulations.dll \
	UIAutomationTypes.dll \
	UIAutomationProvider.dll \
	PresentationCore.dll \
	ReachFramework-PresentationFramework-api.dll \
	System.Printing-PresentationFramework-api.dll
PresentationFramework-ReachFramework-impl_CSREFS =
PresentationFramework-ReachFramework-impl_CSSRCS =

PresentationFramework-System.Printing-impl_CSFLAGS =
PresentationFramework-System.Printing-impl_CSLIBS = \
  System.Xaml.dll \
  WindowsBase.dll \
  System.Windows.Input.Manipulations.dll \
  UIAutomationTypes.dll \
  UIAutomationProvider.dll \
  PresentationCore.dll \
  ReachFramework-PresentationFramework-api.dll \
  System.Printing-PresentationFramework-api.dll
PresentationFramework-System.Printing-impl_CSREFS =
PresentationFramework-System.Printing-impl_CSSRCS =

System.Printing-ref_CSFLAGS =
System.Printing-ref_CSLIBS = \
	System.Xaml.dll \
	WindowsBase.dll \
	UIAutomationTypes.dll \
	UIAutomationProvider.dll \
	PresentationCore.dll \
	PresentationFramework-System.Printing-api.dll \
	ReachFramework-System.Printing-api.dll
System.Printing-ref_CSREFS =
System.Printing-ref_CSSRCS =

ReachFramework_CSFLAGS = -define:REACHFRAMEWORK
ReachFramework_CSLIBS = \
  System.Xaml.dll \
  WindowsBase.dll \
  PresentationCore.dll \
  System.Printing-ref.dll \
  PresentationFramework-ReachFramework-impl.dll
ReachFramework_CSREFS = System.Drawing.dll System.Security.dll
ReachFramework_CSSRCS = System.Windows.Xps.SRID.cs System.Windows.Xps.SRID.resources.cs

PresentationFramework_CSFLAGS = \
	-define:FRAMEWORK_NATIVEMETHODS \
	-define:COMMONDPS \
	-define:PRESENTATIONFRAMEWORK_ONLY \
	-define:PRESENTATIONFRAMEWORK \
	-define:RIBBON_IN_FRAMEWORK
PresentationFramework_CSLIBS = \
  System.Xaml.dll \
  WindowsBase.dll \
  UIAutomationTypes.dll \
  UIAutomationProvider.dll \
  PresentationCore.dll \
  ReachFramework.dll \
  System.Printing-ref.dll \
  PresentationUI-PresentationFramework-impl.dll
PresentationFramework_CSREFS = Accessibility.dll
PresentationFramework_CSSRCS = \
  PresentationFramework.ColumnDefinition.generated.cs \
  PresentationFramework.RowDefinition.generated.cs \
  System.Windows.SRID.cs \
  System.Windows.SRID.resources.cs

WindowsBase.PackageXmlStringTable.generated.cs:
	perl ../../../eng/WpfArcadeSdk/Sdk/tools/GenXmlStringTable.pl -o $@ \
	  -n WindowsBase/MS/Internal/IO/Packaging/PackageXmlNamespaces.txt \
	  -x WindowsBase/MS/Internal/IO/Packaging/PackageXmlStrings.txt \
	  -e MS.Internal.IO.Packaging.PackageXmlEnum \
	  -c MS.Internal.IO.Packaging.PackageXmlStringTable || rm -f $@

PresentationFramework.ColumnDefinition.generated.cs:
	perl PresentationFramework/template.pl \
	  PresentationFramework/MS/Utility/GridContentElementCollection \
	  PresentationFramework/MS/Utility/ColumnDefinition > $@ || rm -f $@

PresentationFramework.RowDefinition.generated.cs:
	perl PresentationFramework/template.pl \
	  PresentationFramework/MS/Utility/GridContentElementCollection \
	  PresentationFramework/MS/Utility/RowDefinition > $@ || rm -f $@

define library_template =
$(1).dll: $(1).sources.flags $(shell cat $(1).sources.list)
$(1).dll: $(1).resources.flags $(shell cat $(1).resources.list)
$(1).dll: AssemblyInfos/$(1).AssemblyInfo.cs
$(1).dll: $($(1)_CSSRCS) $($(1)_CSLIBS)
	$(CSC_LIBRARY) -out:$(if $(2),$(2).dll,$$@) $(CSFLAGS) $(CSLIBS) $($(1)_CSFLAGS) \
	  $(addprefix -addmodule:,$($(1)_CSMODS)) \
	  $(addprefix -r:,$($(1)_CSREFS)) $(addprefix -r:,$($(1)_CSLIBS)) \
	  @$(1).sources.flags $($(1)_CSSRCS) @$(1).resources.flags \
	  AssemblyInfos/$(1).AssemblyInfo.cs
	sn -R $(if $(2),$(2).dll,$$@) mono.snk
	$(if $(2),mv $(2).dll $$@,)
endef

$(eval $(call library_template,System.Xaml))
$(eval $(call library_template,WindowsBase))
$(eval $(call library_template,System.Windows.Input.Manipulations))
$(eval $(call library_template,UIAutomationTypes))
$(eval $(call library_template,UIAutomationProvider))
$(eval $(call library_template,PresentationCore))

$(eval $(call library_template,PresentationFramework-PresentationUI-api,PresentationFramework))
$(eval $(call library_template,ReachFramework-PresentationFramework-api,ReachFramework))
$(eval $(call library_template,ReachFramework-System.Printing-api,ReachFramework))
$(eval $(call library_template,System.Printing-PresentationFramework-api,System.Printing))
$(eval $(call library_template,PresentationFramework-System.Printing-api,PresentationFramework))
$(eval $(call library_template,PresentationUI-PresentationFramework-impl,PresentationUI))
$(eval $(call library_template,PresentationFramework-ReachFramework-impl,PresentationFramework))
$(eval $(call library_template,PresentationFramework-System.Printing-impl,PresentationFramework))
$(eval $(call library_template,System.Printing-ref,System.Printing))

$(eval $(call library_template,ReachFramework))
$(eval $(call library_template,PresentationFramework))
